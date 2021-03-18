namespace API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Extensions;
    using API.Helpers;
    using API.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MessagesController : BaseApiController
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository userRepository;

        /// <summary>The message repository</summary>
        private readonly IMessageRepository messageRepository;

        /// <summary>The mapper</summary>
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="MessagesController" /> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="messageRepository">The message repository.</param>
        /// <param name="mapper">The mapper.</param>
        public MessagesController(IUserRepository userRepository, IMessageRepository messageRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.messageRepository = messageRepository;
            this.mapper = mapper;
        }

        /// <summary>Creates the message.</summary>
        /// <param name="createMessageDto">The create message dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var username = User.GetUsername();

            if (username == createMessageDto.RecipientUsername.ToLower())
            {
                return this.BadRequest("You cannot send messages to yourself");
            }

            var sender = await this.userRepository.GetUserByUsernameAsync(username);
            var recipient = await this.userRepository.GetUserByUsernameAsync(createMessageDto.RecipientUsername);

            if (recipient == null)
            {
                return this.NotFound();
            }

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderUsername = sender.UserName,
                RecipientUsername = recipient.UserName,
                Content = createMessageDto.Content
            };

            this.messageRepository.AddMessage(message);

            if (await this.messageRepository.SaveAllAsync())
            {
                return this.Ok(this.mapper.Map<MessageDto>(message));
            }

            return this.BadRequest("Failed to send message");
        }

        /// <summary>Gets the messages for user.</summary>
        /// <param name="messageParams">The message parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesForUser([FromQuery] MessageParams messageParams)
        {
            messageParams.Username = User.GetUsername();
            var messages = await this.messageRepository.GetMessagesForUser(messageParams);

            Response.AddPaginationHeader(messages.CurrentPage, messages.PageSize, messages.TotalCount, messages.TotalPages);
            return messages;
        }

        /// <summary>Gets the message thread.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("thread/{username}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(string username)
        {
            var currentUsername = User.GetUsername();

            return this.Ok(await this.messageRepository.GetMessageThread(currentUsername, username));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            var username = User.GetUsername();

            var message = await this.messageRepository.GetMessage(id);

            if (message.Sender.UserName != username && message.Recipient.UserName != username)
            {
                return this.Unauthorized();
            }

            if (message.Sender.UserName == username)
            {
                message.SenderDeleted = true;
            }

            if (message.Recipient.UserName == username)
            {
                message.RecipientDeleted = true;
            }

            if (message.SenderDeleted && message.RecipientDeleted)
            {
                this.messageRepository.DeleteMessage(message);
            }

            if (await this.messageRepository.SaveAllAsync())
            {
                return this.Ok();
            }

            return this.BadRequest("Problem deleting the message");
        }
    }
}

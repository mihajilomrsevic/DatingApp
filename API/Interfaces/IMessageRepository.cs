namespace API.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Helpers;

    public interface IMessageRepository
    {
        /// <summary>Adds the message.</summary>
        /// <param name="message">The message.</param>
        void AddMessage(Message message);

        /// <summary>Deletes the message.</summary>
        /// <param name="message">The message.</param>
        void DeleteMessage(Message message);

        /// <summary>Gets the message.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<Message> GetMessage(int id);

        /// <summary>Gets the messages for user.</summary>
        /// <param name="messageParams">The message parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);

        /// <summary>Gets the message thread.</summary>
        /// <param name="currentUsername">The current username.</param>
        /// <param name="recipientUsername">The recipient username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);

        /// <summary>Saves all asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<bool> SaveAllAsync();
    }
}

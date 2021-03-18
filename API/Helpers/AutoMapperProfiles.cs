namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Extensions;
    using AutoMapper;

    public class AutoMapperProfiles : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="AutoMapperProfiles" /> class.</summary>
        public AutoMapperProfiles()
        {
            this.CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            this.CreateMap<Photo, PhotoDto>();
            this.CreateMap<MemberUpdateDto, AppUser>();
            this.CreateMap<RegisterDto, AppUser>();
            this.CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}

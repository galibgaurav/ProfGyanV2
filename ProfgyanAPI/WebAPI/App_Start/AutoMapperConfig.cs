using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profgyan.DTO;
using Profgyan.DataModel;
using AutoMapper;

namespace WebAPI
{
    //public  class AutoMapperProfile :Profile
    //{
    //    //public AutoMapperProfile()
    //    //{
    //    //    //Place code for mapping DTO and entyframework object
    //    //    CreateMap<CourseDTO, Course>();

    //    //}
    //}

    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                //Map CourseDTO to Course and vice versa , ignoring course ID
                config.CreateMap<CourseDTO, Course>().ForMember(dest=>dest.CourseId,opt=>opt.Ignore()).ReverseMap();
                config.CreateMap<AttendanceDTO, Attendance>().ForMember(dest => dest.AttendanceId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<AppointmentDTO, Appointment>().ForMember(dest => dest.AppointmentId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<BidDTO, Bid>().ForMember(dest => dest.BidId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<BookMarkDTO, BookMark>().ForMember(dest => dest.BookmarkId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<ChatDTO, Chat>().ForMember(dest => dest.ChatID, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<CommonDetailDTO, CommonDetail>().ForMember(dest => dest.ID, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<ContactUsDTO, ContactUs>().ForMember(dest => dest.ContactusId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<DocumentDTO, Document>().ForMember(dest => dest.DocumentId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<EnrollmentDTO, Enrollment>().ForMember(dest => dest.EnrollmentId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<FeedbackDTO, Feedback>().ForMember(dest => dest.FeedbackId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<PaymentModeDTO, PaymentMode>().ForMember(dest => dest.ModeId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<RatingDTO, Rating>().ForMember(dest => dest.RatingId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<SessionDTO, Session>().ForMember(dest => dest.SessionId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<SocialMediaDTO, SocialMedia>().ForMember(dest => dest.SocialMediaId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<StatusDTO, Status>().ForMember(dest => dest.StatusId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<SubscriptionDTO, Subscription>().ForMember(dest => dest.SubscriptionId, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<TraineeDTO, Trainee>().ForMember(dest => dest.TraineeID, opt => opt.Ignore()).ReverseMap();
                config.CreateMap<TrainerDTO, Trainer>().ForMember(dest => dest.TrainerId, opt => opt.Ignore()).ReverseMap();
               // config.CreateMap<TrainingTypeDTO, TrainingTyp>().ForMember(dest => dest.TrainerId, opt => opt.Ignore()).ReverseMap();




                //config.CreateMap<CourseDTO, Course>()
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessDataModel;

namespace DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDBContext context = new ApplicationDBContext();
        private Repository<Appointment> appointmentRepository;
        public Repository<Appointment> AppointmentRepository
        {
            get
            {

                if (this.appointmentRepository == null)
                {
                    this.appointmentRepository = new Repository<Appointment>(context);
                }
                return appointmentRepository;
            }
        }

        private Repository<ContactUs> contactUsRepository;

        public Repository<ContactUs> ContactUsRepository
        {
            get
            {

                if (this.contactUsRepository == null)
                {
                    this.contactUsRepository = new Repository<ContactUs>(context);
                }
                return contactUsRepository;
            }
        }

        private Repository<Attendance> attendanceRepository;
        public Repository<Attendance> AttendanceRepository
        {
            get
            {

                if (this.attendanceRepository == null)
                {
                    this.attendanceRepository = new Repository<Attendance>(context);
                }
                return attendanceRepository;
            }
        }
        private Repository<Bid> bidRepository;
        public Repository<Bid> BidRepository
        {
            get
            {

                if (this.bidRepository == null)
                {
                    this.bidRepository = new Repository<Bid>(context);
                }
                return bidRepository;
            }
        }

        private Repository<BookMark> bookMarkRepository;
        public Repository<BookMark> BookMarkRepository
        {
            get
            {

                if (this.bookMarkRepository == null)
                {
                    this.bookMarkRepository = new Repository<BookMark>(context);
                }
                return bookMarkRepository;
            }
        }
        private Repository<Chat> chatRepository;
        public Repository<Chat> ChatRepository
        {
            get
            {

                if (this.chatRepository == null)
                {
                    this.chatRepository = new Repository<Chat>(context);
                }
                return chatRepository;
            }
        }
        private Repository<CommonDetail> commonDetailRepository;

        public Repository<CommonDetail> CommonDetailRepository
        {
            get
            {

                if (this.commonDetailRepository == null)
                {
                    this.commonDetailRepository = new Repository<CommonDetail>(context);
                }
                return commonDetailRepository;
            }
        }
        private Repository<Course> courseRepository;
        public Repository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new Repository<Course>(context);
                }
                return courseRepository;
            }
        }

        private Repository<Document> documentRepository;
        public Repository<Document> DocumentRepository
        {
            get
            {

                if (this.documentRepository == null)
                {
                    this.documentRepository = new Repository<Document>(context);
                }
                return documentRepository;
            }
        }

        private Repository<Enrollment> enrollmentRepository;

        public Repository<Enrollment> EnrollmentRepository
        {
            get
            {

                if (this.enrollmentRepository == null)
                {
                    this.enrollmentRepository = new Repository<Enrollment>(context);
                }
                return enrollmentRepository;
            }
        }

        private Repository<Feedback> feedbackRepository;

        public Repository<Feedback> FeedbackRepository
        {
            get
            {

                if (this.feedbackRepository == null)
                {
                    this.feedbackRepository = new Repository<Feedback>(context);
                }
                return feedbackRepository;
            }
        }
        private Repository<PaymentMode> paymentModeRepository;

        public Repository<PaymentMode> PaymentModeRepository
        {
            get
            {

                if (this.paymentModeRepository == null)
                {
                    this.paymentModeRepository = new Repository<PaymentMode>(context);
                }
                return paymentModeRepository;
            }
        }

        private Repository<Rating> ratingRepository;

        public Repository<Rating> RatingRepository
        {
            get
            {

                if (this.ratingRepository == null)
                {
                    this.ratingRepository = new Repository<Rating>(context);
                }
                return ratingRepository;
            }
        }
        private Repository<Session> sessionRepository;
        public Repository<Session> SessionRepository
        {
            get
            {

                if (this.sessionRepository == null)
                {
                    this.sessionRepository = new Repository<Session>(context);
                }
                return sessionRepository;
            }
        }
        private Repository<SocialMedia> socialMediaRepository;
        public Repository<SocialMedia> SocialMediaRepository
        {
            get
            {

                if (this.socialMediaRepository == null)
                {
                    this.socialMediaRepository = new Repository<SocialMedia>(context);
                }
                return socialMediaRepository;
            }
        }
        private Repository<Status> statusRepository;

        public Repository<Status> StatusRepository
        {
            get
            {

                if (this.statusRepository == null)
                {
                    this.statusRepository = new Repository<Status>(context);
                }
                return statusRepository;
            }
        }
        private Repository<Subscription> subscriptionRepository;

        public Repository<Subscription> SubscriptionRepository
        {
            get
            {

                if (this.subscriptionRepository == null)
                {
                    this.subscriptionRepository = new Repository<Subscription>(context);
                }
                return subscriptionRepository;
            }
        }
        private Repository<Trainee> traineeRepository;

        public Repository<Trainee> TraineeRepository
        {
            get
            {

                if (this.traineeRepository == null)
                {
                    this.traineeRepository = new Repository<Trainee>(context);
                }
                return traineeRepository;
            }
        }
        private Repository<Trainer> trainerRepository;
        public Repository<Trainer> TrainerRepository
        {
            get
            {

                if (this.trainerRepository == null)
                {
                    this.trainerRepository = new Repository<Trainer>(context);
                }
                return trainerRepository;
            }
        }

        private Repository<TrainerDetail> trainerDetailRepository;

        public Repository<TrainerDetail> TrainerDetailRepository
        {
            get
            {

                if (this.trainerDetailRepository == null)
                {
                    this.trainerDetailRepository = new Repository<TrainerDetail>(context);
                }
                return trainerDetailRepository;
            }
        }
        private Repository<TrainingType> trainingTypeRepository;
        public Repository<TrainingType> TrainingTypeRepository
        {
            get
            {

                if (this.trainingTypeRepository == null)
                {
                    this.trainingTypeRepository = new Repository<TrainingType>(context);
                }
                return trainingTypeRepository;
            }
        }
        private Repository<ValidationPasscode> validationPasscodeRepository;

        public Repository<ValidationPasscode> ValidationPasscodeRepository
        {
            get
            {

                if (this.validationPasscodeRepository == null)
                {
                    this.validationPasscodeRepository = new Repository<ValidationPasscode>(context);
                }
                return validationPasscodeRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

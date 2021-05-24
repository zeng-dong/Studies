using DomainEventsWithMediatr.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;

namespace DomainEventsWithMediatr.Entities
{
    public class Appointment : IEntity
    {
        public Guid Id { get; private set; }
        public string EmailAddress { get; private set; }
        public DateTime? ConfirmationReceivedDate { get; private set; }

        public List<INotification> Events { get; set; } = new List<INotification>();
        protected Appointment() : this(Guid.NewGuid())
        {
        }

        public Appointment(Guid id)
        {
            this.Id = id;
        }

        public static Appointment Create(string emailAddress)
        {
            Console.WriteLine("Appointment::Create()");

            var appointment = new Appointment();
            appointment.EmailAddress = emailAddress;

            // send an email - pretend there's 5-10 lines of code here to send an email
            Console.WriteLine("Notification email sent to {0}", emailAddress);

            // update the user interface
            // pretend some code here pops up a notification in the UI
            // or sends a message via Blazor
            Console.WriteLine("User Interface informed appointment created for {0}", emailAddress);

            return appointment;
        }

        public void Confirm(DateTime dateConfirmed)
        {
            ConfirmationReceivedDate = dateConfirmed;

            Console.WriteLine("[UI] User Interface informed appointment for {0} confirmed at {1}",
                            EmailAddress,
                            ConfirmationReceivedDate.ToString());
        }
    }
}

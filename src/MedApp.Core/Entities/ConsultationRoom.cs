using MedApp.Core.Exceptions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Entities
{
    public class ConsultationRoom
    {
        public ConsultationRoomId Id { get; private set; }
        public ConsultationRoomName Name { get; private set; }

        private ConsultationRoom(ConsultationRoomId id, ConsultationRoomName name) 
        {
            Id = id;
            Name = name; 
        }

        public static ConsultationRoom Create(ConsultationRoomId id, ConsultationRoomName name)
            => new(id, name);

    }
    
}

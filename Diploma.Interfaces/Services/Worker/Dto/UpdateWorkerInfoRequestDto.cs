﻿using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Worker.Dto
{
    public class UpdateWorkerInfoRequestDto : BaseRequestDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TransportTypeEnum TransportType { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public int CrewId { get; set; }
    }
}

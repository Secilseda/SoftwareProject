using SoftwareProject.Kernel.Entity.Abstract;
using SoftwareProject.Kernel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Kernel.Entity.Concrete
{
	public class KernelEntity : IEntity<Guid>//
	{
		public Guid Id { get; set; }

		public DateTime CreateDate { get; set; }
		public string CreatedComputerName { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedIp { get; set; }


		public DateTime? ModifiedDate { get; set; }
		public string ModifiedComputerName { get; set; }
		public string ModifiedIp { get; set; }
		public string ModifiedBy { get; set; }//kim tarafından modified edildi.


		public Status Status { get; set; }
	}
}

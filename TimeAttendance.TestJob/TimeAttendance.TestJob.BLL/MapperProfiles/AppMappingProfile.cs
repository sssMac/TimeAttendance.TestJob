using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models.ViewModels;
using TimeAttendance.TestJob.DAL.Models.Entities;

namespace TimeAttendance.TestJob.BLL.MapperProfiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<AddTask, SmallTask>();

			CreateMap<AddTask, TaskComments>();
			CreateMap<UpdateTask, SmallTask>();
		}
	}
}

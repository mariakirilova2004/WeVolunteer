﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Cause;
using WeVolunteer.Infrastructure.Data.Entities;

namespace WeVolunteer.Core.Services.Cause
{
    public interface ICauseService
    {
        List<PhotoCause> GetPhotosByCauseId(int id);

        AllCausesQueryModel All(string category = null,
                                          string searchTerm = null,
                                          CauseSorting sorting = CauseSorting.Newest,
                                          int currentPage = 1,
                                          int causesPerPage = 1);

        Task<bool> Exists(int id);

        CauseDetailsViewModel CauseDetailsById(int id);

        Task BecomePartAsync(int id, string userId);

        Task<bool> IsMadeBy(int id, string userId);

        MineCausesQueryModel Mine(string category, string searchTerm, CauseSorting sorting, int currentPage, int causesPerPage, string userId);
        bool CauseWithNameExists(string name, string userId);
        Task CreateAsync(int organizationId, string name, string place, DateTime time, string description, IFormFile image, int categoryId);
        Task Edit(int id, string name, string place, DateTime time, string description, IFormFile image, int categoryId);
        Task Delete(int id);
        Task Cancel(int id, string userId);
        public bool IsAlreadyPart(string userId, int id);
    }
}

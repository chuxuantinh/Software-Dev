﻿using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;

namespace PetStore.Web.Models.Pets
{
    public class AllPetsViewModel
    {
        public IEnumerable<PetListingServiceModel> Pets { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;

        public bool PreviuosDisabled => this.CurrentPage == 1;

        public int Total { get; set; }

        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling(((double)this.Total) / 25);

                return maxPage == this.CurrentPage;
            }
        }
    }
}

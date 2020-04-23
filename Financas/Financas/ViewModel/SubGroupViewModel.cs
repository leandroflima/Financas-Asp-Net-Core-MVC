using Financas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Financas.ViewModel
{
    public class SubGroupViewModel
    {
        public SubGroupViewModel()
        {
        }

        public SubGroupViewModel(SubGroup subGroup, List<Group> groups)
        {
            Id = subGroup.Id;
            
            Description = subGroup.Description;

            if (string.IsNullOrEmpty(Id))
            {
                Group = new Group();
            }
            else
            {
                Group = groups.First(a => a.Id.Equals(subGroup.GroupId));
            }
            
            Groups = new SelectList(groups, "Id", "Description");
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public Group Group { get; set; }

        public SelectList Groups { get; set; }
    }
}

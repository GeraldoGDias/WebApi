using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {

            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}

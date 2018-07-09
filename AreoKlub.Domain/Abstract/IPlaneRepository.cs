using AreoKlub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreoKlub.Domain.Abstract
{
    public interface IPlaneRepository
    {

        IEnumerable<Samolot> Samoloty { get; }

        void AddPlane(Samolot samolot);

        void DeletePlane(string Name);

       

    }
}

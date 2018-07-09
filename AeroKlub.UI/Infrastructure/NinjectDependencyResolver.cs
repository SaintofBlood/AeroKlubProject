using AeroKlub.UI.Infrastructure.Abstract;
using AeroKlub.UI.Infrastructure.Concrate;
using AreoKlub.Domain.Abstract;
using AreoKlub.Domain.Concrate;
using AreoKlub.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AeroKlub.UI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParm)
        {
            kernel = kernelParm;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type servicetype)
        {
            return kernel.GetAll(servicetype);
        }

        private void AddBindings()
        {
            /*
            Mock<IPlaneRepository> mock = new Mock<IPlaneRepository>();
            mock.Setup (m => m.Samoloty).Returns(new List<Samolot>{

                new Samolot{Nazwa = "XYZXDDD" , PlaneID = 1},
                new Samolot{Nazwa = "TEST" , PlaneID = 2}
            });

            kernel.Bind<IPlaneRepository>().ToConstant(mock.Object);
            */
            kernel.Bind<IPlaneRepository>().To<EFPlaneRepository>();
            kernel.Bind<IReservationRepository>().To<EFReservationRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            kernel.Bind<IUsersRepository>().To<EFUsersRepository>();
            kernel.Bind<IServicesRepository>().To<EFServicesRepository>();
        }

    }
}
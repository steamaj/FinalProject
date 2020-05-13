using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using ToyBox.Domain.Abstract;
using ToyBox.Domain.Entities;
using ToyBox.Domain.Concrete;
using System.Configuration;
using ToyBox.WebUI.Infrastructure.Abstract;
using ToyBox.WebUI.Infrastructure.Concrete;


namespace ToyBox.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelparam)
        {
            mykernel = kernelparam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            /* Mock<IUserRepository> mock = new Mock<IUserRepository>();
             mock.Setup(m => m.Users).Returns(new List<User>
             {
                 new User {Email = "example@example.com", Password = "Password01"}
             });
             mykernel.Bind<IUserRepository>().ToConstant(mock.Object);*/

            mykernel.Bind<IUserRepository>().To<EFUserRepository>();





            mykernel.Bind<IProductRepository>().To<EFProductRepository>();



            mykernel.Bind<IAuthProviders>().To<FormAuthProviders>();



            mykernel.Bind<IConditionRepository>().To<EFConditionRepository>();
        }
    }
}
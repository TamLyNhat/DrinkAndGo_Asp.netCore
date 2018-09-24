using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

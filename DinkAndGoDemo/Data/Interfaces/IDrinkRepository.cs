using DinkAndGoDemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinkAndGoDemo.Data.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; }
        Drink GetDrinkById(int drinkId);
    }
}

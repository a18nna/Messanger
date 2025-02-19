using Messanger.BLL.Exceptions;
using Messanger.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.PLL.Views
{
    public class AddFriendView
    {
        public FriendService friendService;
        public AddFriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(int userCurrentId)
        {
            Console.WriteLine("Добавление в друзья");
            Console.Write("Введите email друга: ");
            string friendEmail = Console.ReadLine();

            try
            {
                friendService.AddFriend(userCurrentId, friendEmail);
                Console.WriteLine("Пользователь успешно добавлен в друзья!");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}

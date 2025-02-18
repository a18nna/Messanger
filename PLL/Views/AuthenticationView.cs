using Messanger.BLL.Exceptions;
using Messanger.BLL.Models;
using Messanger.BLL.Services;
using System;

namespace Messanger.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;

        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = this.userService.Authenticate(authenticationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожуловать, " + user.FirstName);

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }
            catch(UserNotFoundException)
            {
                Console.WriteLine("Пользователь не найден!");
            }
        }
    }
}

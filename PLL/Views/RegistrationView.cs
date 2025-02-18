using Messanger.BLL.Exceptions;
using Messanger.BLL.Models;
using Messanger.BLL.Services;
using System;

namespace Messanger.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.Write("Ваше имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Ваш email: ");
            userRegistrationData.Email = Console.ReadLine();

            Console.Write("Придумайте пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            try
            {
                this.userService.Register(userRegistrationData);
                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введите корректное значение!");
            }
            catch (ExistingEmailException)
            {
                Console.WriteLine("Пользователь с такой почтой уже зарегистрирован!");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при регистрации!");
            }
        }
    }
}

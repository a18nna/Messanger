﻿using Messanger.BLL.Exceptions;
using Messanger.BLL.Services;
using Messanger.BLL.Models;
using Messanger.PLL;
using System;

namespace Messanger.PLL.Views
{
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;
        public MessageSendingView(MessageService messageService, UserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.Write("Введите почтовый адрес получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение (не больше 5000 символов): ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                SuccessMessage.Show("Сообщение успешно отправлено!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }

        }
    }
}

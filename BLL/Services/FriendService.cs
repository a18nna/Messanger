using Messanger.DAL.Repositories;
using Messanger.BLL.Models;
using System.Collections.Generic;
using Massenger.BLL.Models;
using Messanger.BLL.Exceptions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using Messanger.DAL;

namespace Messanger.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(int userId, string friendEmail)
        {
            var friendUser = userRepository.FindByEmail(friendEmail);

            if (friendUser == null)
                throw new UserNotFoundException();

            var friendExisting = friendRepository.FindAllByUserId(userId).FirstOrDefault(f => f.friend_id == friendUser.id);

            if (friendExisting != null)
            {
                throw new InvalidOperationException("Этот пользователь уже у вас в друзьях.");

            }

            var friendEntity = new FriendEntity
            {
                user_id = userId,
                friend_id = friendUser.id
            };

            friendRepository.Create(friendEntity);
        }

        public void DeleteFriend(int userId, string friendEmail)
        {
            var friendUser = userRepository.FindByEmail(friendEmail);

            if (friendUser == null)
                throw new UserNotFoundException();

            var friendExisting = friendRepository.FindAllByUserId(userId).FirstOrDefault(f => f.friend_id == friendUser.id);

            friendRepository.Delete(friendExisting.friend_id);
        } 
    }
}

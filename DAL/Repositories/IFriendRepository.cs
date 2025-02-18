using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.DAL.Repositories
{
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
    }
}

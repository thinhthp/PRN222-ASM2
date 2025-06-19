using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zQuitSmoking.Repositories.ThinhTHP.Basic;
using zQuitSmoking.Repositories.ThinhTHP.DBContext;
using zQuitSmoking.Repositories.ThinhTHP.Models;

namespace zQuitSmoking.Repositories.ThinhTHP
{
    public class UserNotificationThinhThpRepository : GenericRepository<UserNotificationThinhThp>
    {
        public UserNotificationThinhThpRepository() { }

        public UserNotificationThinhThpRepository(SE18_PRN222_SE1809_G6_QuitSmokingDBContext context) => _context = context;

        public async Task<List<UserNotificationThinhThp>> GetAllAsync()
        {
            var item = await _context.UserNotificationThinhThps
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .ToListAsync();
            return item ?? new List<UserNotificationThinhThp>();
        }

        public new async Task<UserNotificationThinhThp> GetByIdAsync(int id)
        {
            var item = await _context.UserNotificationThinhThps
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .FirstOrDefaultAsync(x => x.UserNotificationThinhThpid == id);
            return item ?? new UserNotificationThinhThp();
        }

        public async Task<List<UserNotificationThinhThp>> SearchAsync(string message, string response, string userName)
        {
            var items = await _context.UserNotificationThinhThps
                .Include(x => x.NotificationThinhThp).Include(x => x.UserAccount)
                .Where(x =>
                (x.NotificationThinhThp.Message.Contains(message) || string.IsNullOrEmpty(message))
                && (x.Response.Contains(response) || string.IsNullOrEmpty(response))
                //&& (userId == 0 || x.UserAccount.UserAccountId == userId))
                && (x.UserAccount.UserName.Contains(userName) || string.IsNullOrEmpty(userName)))
                .ToListAsync();
            return items ?? new List<UserNotificationThinhThp>();
        }
    }
}

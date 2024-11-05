using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DataStructure;
namespace Showtime
{
    public class ShowTimeManager
    {
        private datastructure _data;
        private database db;

        public ShowTimeManager(datastructure data)
        {
            this._data = data;
            db = new database();
        }


        public void AddShowTime(string movieId, DateTime showDateTime, string hall)
        {
            try
            {
                ShowTime newShowTime = new ShowTime(movieId, showDateTime, hall);
                _data.Showtimes.Add(newShowTime);
                Console.WriteLine("Lịch chiếu đã được thêm thành công.");
                db.saveShowtimeData(_data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm lịch chiếu: {ex.Message}");
            }
        }


        public void RemoveShowTime(string MovieId)
        {
            if(_data.Showtimes == null)
            {
                Console.WriteLine("Danh sách lịch chiếu rỗng,không thể xóa");
                return;
            }
            try
            {
                ShowTime? showTimeToRemove = _data.Showtimes.Find(st => st.movieID == MovieId);
                if (showTimeToRemove != null) //// Kiểm tra nếu không phải là null
                {
                    _data.Showtimes.Remove(showTimeToRemove.Value);  // Sử dụng .Value để lấy giá trị thực
                    Console.WriteLine("Lịch chiếu đã được xóa thành công.");
                    db.saveShowtimeData(_data);
                }
                else
                {
                    Console.WriteLine("Lịch chiếu không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa lịch chiếu: {ex.Message}");
            }
        }


        public ShowTime? SearchShowTime(string MovieID)
        {
            // ShowTime? co nghia la no co the chap nhan null(nullable)
            try
            {
                ShowTime? foundShowTime = _data.Showtimes.Find(st => st.movieID == MovieID);

                if (foundShowTime == null)
                {
                    Console.WriteLine("Lịch chiếu không tồn tại.");
                }

                return foundShowTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm lịch chiếu: {ex.Message}");
                return null;
            }
        }


        public void DisplayShowTimes()
        {
            try
            {
                if (_data.Showtimes.Count == 0)
                {
                    Console.WriteLine("Không có lịch chiếu nào.");
                    return;
                }

                Console.WriteLine("Danh sách lịch chiếu:");
                foreach (var showTime in _data.Showtimes)
                {
                    Console.WriteLine($"Movie ID: {showTime.movieID}, Thời gian: {showTime.showDateTime}, Sảnh: {showTime.hall}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi hiển thị lịch chiếu: {ex.Message}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;
using datastructure;
namespace Showtime
{
    public class ShowTimeManager
    {
        private DataStructure _data;
        private DataBase db;

        public ShowTimeManager(DataStructure data)
        {
            this._data = data;
            db = new DataBase();
        }


        public void AddShowTime(string movieId, DateTime showDateTime, string hall)
        {
            try
            {
                ShowTime newShowTime = new ShowTime(movieId, showDateTime, hall);
                _data.Showtimes.AddLast(newShowTime);
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
            // Kiểm tra nếu dslk của Showtimes rỗng thì báo lỗi
            if (_data.Showtimes.Count == 0 || !_data.Showtimes.Any())
            {
                Console.WriteLine("Danh sách lịch chiếu rỗng, không thể xóa.");
                return;
            }
            // Ngược lại, duyệt qua dslk Showtimes và tìm phần tử có MovieId cần xoá
            try
            {
                var node = _data.Showtimes.First;
                while (node != null)
                {
                    if (node.Value.movieID == MovieId)
                    {
                        _data.Showtimes.Remove(node);
                        Console.WriteLine("Lịch chiếu đã được xóa thành công.");
                        db.saveShowtimeData(_data);
                        return;
                    }
                    node = node.Next;
                }
                Console.WriteLine("Lịch chiếu không tồn tại.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa lịch chiếu: {ex.Message}");
            }
        }


        public ShowTime? SearchShowTime(string MovieId)
        {
            // ShowTime? co nghia la no co the chap nhan null (nullable)
            try
            {
                var node = _data.Showtimes.First;
                while (node != null)
                {
                    if (node.Value.movieID == MovieId)
                    {
                        return node.Value;
                    }
                    node = node.Next;
                }
                Console.WriteLine("Lịch chiếu không tồn tại.");
                return null;
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
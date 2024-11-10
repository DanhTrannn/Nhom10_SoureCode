using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using datastructure;
using System.Threading;

namespace database
{
    public class DataBase
    {
        public string customerFilePath = "Customer.txt";
        public string movieFilePath = "Movies.txt";
        public string showTimeFilePath = "Showtime.txt";
        public void loadCustomerData(DataStructure data)
        {
            // Kiểm tra file có tồn tại không?
            if (File.Exists(customerFilePath))
            {
                // Mở file và trả về mảng lines chứa các dòng dữ liệu
                var lines = File.ReadAllLines(customerFilePath);
                // Duyệt qua tất cả các dòng dữ liệu
                foreach (var line in lines)
                {
                    // Tách dữ liệu trên 1 dòng thông qua các dấu phẩy và trả về mảng parts
                    var parts = line.Split(',');
                    // Kiểm tra xem nếu 1 dòng có đủ 5 phần dữ liệu thì tạo một đối tượng Customer mới
                    // Sau đó thêm vào cấu trúc dữ liệu
                    if (parts.Length == 5)
                    {
                        Customer tmp = new Customer();
                        tmp.id = (parts[0]);
                        tmp.name = (parts[1]);
                        tmp.email = (parts[2]);
                        tmp.phoneNumber = (parts[3]);
                        tmp.personalCode = (parts[4]);
                        data.customers.AddLast(tmp);
                    }
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + customerFilePath);
            }
        }

        public void loadMovieData(DataStructure data)
        {
            if (File.Exists(movieFilePath))
            {
                var lines = File.ReadAllLines(movieFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Movies tmp = new Movies();
                        tmp.movieID = (parts[0]);
                        tmp.movieName = (parts[1]);
                        tmp.genre = (parts[2]);
                        tmp.duration = (parts[3]);
                        data.movies.AddLast(tmp);
                    }
                }
            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + movieFilePath);
            }
        }

        public void loadShowtimeData(DataStructure data)
        {
            if (File.Exists(showTimeFilePath))
            {
                var lines = File.ReadAllLines(showTimeFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        ShowTime tmp = new ShowTime();
                        tmp.movieID = parts[0];
                        tmp.showDateTime = (DateTime.Parse(parts[1]));
                        tmp.hall = (parts[2]);
                        data.showtimes.AddLast(tmp);
                    }
                }

            }
            else
            {
                Console.WriteLine("Không tồn tại file: " + showTimeFilePath);
            }
        }

        public void saveCustomerData(DataStructure data)
        {
            using (var writer = new StreamWriter(customerFilePath))
            {
                Node<Customer> current = data.customers.head;
                while (current != null)
                {
                    Customer customer = current.data;
                    writer.WriteLine($"{customer.id},{customer.name},{customer.email},{customer.phoneNumber},{customer.personalCode}");
                    current = current.next;
                }
            }
        }
        public void saveMovieData(DataStructure data)
        {
            using (var writer = new StreamWriter(movieFilePath))
            {
                Node<Movies> current = data.movies.head;
                while (current != null)
                {
                    Movies movie = current.data;
                    writer.WriteLine($"{movie.movieID},{movie.movieName},{movie.genre},{movie.duration}");
                    current = current.next;
                }
            }
        }
        public void saveShowtimeData(DataStructure data)
        {
            using (var writer = new StreamWriter(showTimeFilePath))
            {
                Node<ShowTime> current = data.showtimes.head;
                while (current != null)
                {
                    ShowTime showtime = current.data;
                    writer.WriteLine($"{showtime.movieID},{showtime.showDateTime},{showtime.hall}");
                    current = current.next;
                }
            }
        }
    }
}

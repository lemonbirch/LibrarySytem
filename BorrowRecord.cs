using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BorrowRecord
{
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public BorrowRecord(int bookId, int borrowerId, DateTime borrowDate)
    {
        BookId = bookId;
        BorrowerId = borrowerId;
        BorrowDate = borrowDate;
        ReturnDate = null;
    }
}
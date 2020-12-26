namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        Dictionary<string, Invoice> bySerial = new Dictionary<string, Invoice>();

        public void Create(Invoice invoice)
        {
            if (bySerial.ContainsKey(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            bySerial[invoice.SerialNumber] = invoice;
        }

        public void ThrowInvoice(string number)
        {
            if (!bySerial.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            bySerial.Remove(number);
        }

        public void ThrowPayed()
        {
            var toRemove = bySerial.Values.Where(i => i.Subtotal == 0).Select(i => i.SerialNumber).ToList();

            foreach (var serialNumber in toRemove)
            {
                bySerial.Remove(serialNumber);
            }
        }

        public int Count()
        {
            return bySerial.Count;
        }

        public bool Contains(string number)
        {
            return bySerial.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var dueTo = bySerial.Values.Where(i => i.DueDate.Date == due.Date);
            if (dueTo.Count() == 0)
            {
                throw new ArgumentException();
            }
            foreach (var item in dueTo)
            {
                item.Subtotal = 0;
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            return bySerial.Values.Where(i => start.Date <= i.IssueDate.Date && i.IssueDate.Date <= end.Date).OrderBy(i => i.IssueDate).ThenBy(i => i.DueDate);
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var keys = bySerial.Keys.Where(k => k.Contains(serialNumber));
            if (keys.Count() == 0)
            {
                throw new ArgumentException();
            }
            return keys.OrderByDescending(k => k).Select(k => bySerial[k]);
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var invoicesForRemove = bySerial.Values.Where(i => start.Date < i.DueDate.Date && i.DueDate.Date < end.Date);
            if (invoicesForRemove.Count() == 0)
            {
                throw new ArgumentException();
            }
            foreach (var item in invoicesForRemove)
            {
                bySerial.Remove(item.SerialNumber);
            }
            return invoicesForRemove;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            return bySerial.Values.Where(i => i.Department == department).OrderByDescending(i => i.Subtotal).ThenBy(i => i.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return bySerial.Values.Where(i => i.CompanyName == company).OrderByDescending(i => i.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var forUpdate = bySerial.Values.Where(i => i.DueDate.Date == dueDate.Date);
            if (forUpdate.Count() == 0)
            {
                throw new ArgumentException();
            }
            foreach (var item in forUpdate)
            {
                item.DueDate = item.DueDate.AddDays(days);
            }
        }
    }
}

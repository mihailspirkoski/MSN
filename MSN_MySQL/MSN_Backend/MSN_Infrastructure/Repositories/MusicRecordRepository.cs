using MSN_Application.Interfaces;
using MSN_Domain.Entities;
using MSN_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSN_Infrastructure.Repositories
{
    public class MusicRecordRepository : IMusicRecordRepository<MusicRecord>
    {

        private readonly ApplicationDbContext _context;

        public MusicRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Delete(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }
            _context.MusicRecords.Remove(record);
            _context.SaveChanges();
        }

        public MusicRecord Get(int id)
        {
            return _context.MusicRecords.SingleOrDefault(z => z.Id == id);
        }

        public List<MusicRecord> GetAll()
        {
            return _context.MusicRecords.ToList();
        }

        public void Insert(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            _context.MusicRecords.Add(record);
            _context.SaveChanges();
        }

        public void Update(MusicRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            _context.MusicRecords.Update(record);
            _context.SaveChanges();
        }
    }
}

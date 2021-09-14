using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Domain.Entidades.DTO
{
    public class PaginationDTO
    {
        public int Page { get; set; }
        private int recordsPage = 10;
        private readonly int maxPageRecords = 50;

        public int RecordsPage
        {
            get
            {
                return recordsPage;
            }
            set
            {
                recordsPage = (value > maxPageRecords) ? maxPageRecords : value;
            }
        }
    }
}

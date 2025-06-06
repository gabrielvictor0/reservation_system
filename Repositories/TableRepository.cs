﻿using Microsoft.AspNetCore.JsonPatch;
using reservation_system.Contexts;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;

namespace reservation_system.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ServiceDbContext _ctx;

        public TableRepository(ServiceDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<TableDomain> ListTables()
        {
            return _ctx.table.ToList();
        }

        public void RegisterTable(TableDTO newTable)
        {
            TableDomain table = new ()
            {
                name = newTable.name,
                capacity = newTable.capacity,
                status = newTable.status
            };

            _ctx.table.Add(table);
            _ctx.SaveChanges();
        }

        public void RemoveTable(int id)
        {

            try
            {
                TableDomain table = _ctx.table.Find(id)!;

                if (table != null)
                {
                    _ctx.table.Remove(table);
                    _ctx.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        public void UpdateTable(TableDTO tableDTO, int id)
        {
            var table = _ctx.table.Find(id);

            if(tableDTO.name != null)
            {
                table!.name = tableDTO.name;
            }

            if (tableDTO.capacity.HasValue)
            {
                table!.capacity = tableDTO.capacity;
            }

            if(tableDTO.status != null)
            {
                table!.status = tableDTO.status;
            }

            _ctx.table.Update(table!);
            _ctx.SaveChanges();
        }
    }
}

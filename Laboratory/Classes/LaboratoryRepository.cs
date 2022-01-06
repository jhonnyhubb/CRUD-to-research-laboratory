using System;
using System.Collections.Generic;
using DIO.Laboratory.Interfaces;

namespace DIO.Laboratory
{
	public class LaboratoryRepository : IRepository<Item>
	{
        private List<Item> listItens = new List<Item>();
		public void Update(int id, Item objeto)
		{
			listItens[id] = objeto;
		}

		public void Delete(int id)
		{
			listItens[id].Delete();
		}

		public void Insert(Item objeto)
		{
			listItens.Add(objeto);
		}

		public List<Item> List()
		{
			return listItens;
		}

		public int NextId()
		{
			return listItens.Count;
		}

		public Item ReturnId(int id)
		{
			return listItens[id];
		}
	}
}
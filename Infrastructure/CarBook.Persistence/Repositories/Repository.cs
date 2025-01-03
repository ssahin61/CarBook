﻿using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly CarBookContext _context;

		public Repository(CarBookContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			if (entity == null)
			{
				throw new KeyNotFoundException($"Entity with id {id} not found.");
			}
			return entity;
		}

		public async Task RemoveAsync(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
			}
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

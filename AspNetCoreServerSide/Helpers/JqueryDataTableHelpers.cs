using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreServerSide.Helpers
{
	public static class JqueryDataTableHelpers
	{
		public static async Task<JqueryDataTablesExcelResult<T>> GetJqueryDataTablesExcelResultAsync<T, TEntity>(JqueryDataTablesParameters @params, IQueryable<TEntity> query, IConfigurationProvider configurationProvider, bool convertAllData = false, string sheetName = "sheetName", string fileName = "fileName")
		{
			if (@params == null)
			{
				throw new ArgumentNullException($"{nameof(@params)} cannot be null!");
			}

			if (query == null)
			{
				throw new ArgumentNullException($"{nameof(query)} cannot be null!");
			}

			var results = new JqueryDataTablesPagedResults<T>();

			if (convertAllData)
			{
				var items = await query
					.ProjectTo<T>(configurationProvider)
					.ToArrayAsync();
				results.Items = items;
			}
			else
			{
				query = new SearchOptionsProcessor<T, TEntity>().Apply(query, @params.Columns);
				query = new SortOptionsProcessor<T, TEntity>().Apply(query, @params);

				var items = await query
					.Skip((@params.Start / @params.Length) * @params.Length)
					.Take(@params.Length)
					.ProjectTo<T>(configurationProvider)
					.ToArrayAsync();

				results.Items = items;
			}

			return new JqueryDataTablesExcelResult<T>(results.Items, sheetName, fileName);
		}

		public static async Task<JqueryDataTablesResult<T>> GetJqueryDataTablesResultAsync<T, TEntity>(JqueryDataTablesParameters @params, IQueryable<TEntity> query, IConfigurationProvider configurationProvider)
		{
			if (@params == null)
			{
				throw new ArgumentNullException($"{nameof(@params)} cannot be null!");
			}

			if (query == null)
			{
				throw new ArgumentNullException($"{nameof(query)} cannot be null!");
			}

			query = new SearchOptionsProcessor<T, TEntity>().Apply(query, @params.Columns);
			query = new SortOptionsProcessor<T, TEntity>().Apply(query, @params);

			var size = await query.CountAsync();

			if (@params.Length <= 0)
			{
				@params.Length = size;
			}

			var items = await query
				.Skip((@params.Start / @params.Length) * @params.Length)
				.Take(@params.Length)
				.ProjectTo<T>(configurationProvider)
				.ToArrayAsync();

			var results = new JqueryDataTablesPagedResults<T>
			{
				Items = items,
				TotalSize = size
			};

			return new JqueryDataTablesResult<T>
			{
				Draw = @params.Draw,
				Data = results.Items,
				RecordsFiltered = results.TotalSize,
				RecordsTotal = results.TotalSize
			};
		}
	}
}

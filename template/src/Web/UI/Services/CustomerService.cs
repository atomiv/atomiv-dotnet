using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Web.UI.Clients;
using Optivem.Template.Web.UI.Models;
using Optivem.Template.Web.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(Client client)
            : base(client)
        {

        }

        public async Task<IList<Customer>> ListCustomers()
        {
            var response = await Client.Customers.ListCustomers(new ListCustomersRequest());

            return response.Records.Select(Get).ToList();

            /*

            var response = await ClientFactory.GetAsync<List<Customer>>();

            // TODO: VC: View model between

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed status code from REST API");
            }

            return response.Data;
            */
        }

        private Customer Get(ListCustomersRecordResponse record)
        {
            return new Customer
            {
                Id = record.Id,
                FirstName = record.FirstName,
                LastName = record.LastName,
            };
        }
    }


    // TODO: VC: DELETE

    /*
     * 
     * 
     * 

  constructor(private http: HttpClient) { }
  
  getSuppliers (): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(apiUrl)
      .pipe(
        tap(heroes => console.log('fetched suppliers')),
        catchError(this.handleError('getSuppliers', []))
      );
  }

  getSupplier(id: number): Observable<Supplier> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Supplier>(url).pipe(
      tap(_ => console.log(`fetched supplier id=${id}`)),
      catchError(this.handleError<Supplier>(`getSupplier id=${id}`))
    );
  }

  addSupplier (supplier): Observable<Supplier> {
    return this.http.post<Supplier>(apiUrl, supplier, httpOptions).pipe(
      tap((supplier: Supplier) => console.log(`added supplier w/ id=${supplier.id}`)),
      catchError(this.handleError<Supplier>('addSupplier'))
    );
  }

  updateSupplier (id, supplier): Observable<any> {
    const url = `${apiUrl}/${id}`;
    return this.http.put(url, supplier, httpOptions).pipe(
      tap(_ => console.log(`updated supplier id=${id}`)),
      catchError(this.handleError<any>('updateSupplier'))
    );
  }

  deleteSupplier (id): Observable<Supplier> {
    const url = `${apiUrl}/${id}`;

    return this.http.delete<Supplier>(url, httpOptions).pipe(
      tap(_ => console.log(`deleted supplier id=${id}`)),
      catchError(this.handleError<Supplier>('deleteSupplier'))
    );
  }
    
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
     * 
     * 
     */
}

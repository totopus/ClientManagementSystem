import { Injectable } from '@angular/core';
import { Employee } from 'src/app/shared/models/employee';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http:HttpClient) { }

  getEmployeeDetailById(id: number): Observable<Employee> {
    // appsetting.json 
    // https://localhost:5001/api/movies/3
    return this.http.get<Employee>(`${environment.apiUrl}employee/${id}`);
  }

  
  getAllEmployees(): Observable<Employee[]> {
    // call our API, using HttpClient (XMLHttpRequest) to make GET request
    // HttpClient class comes from HttpClientModule (Angular Team created for us to use)
    // import HttpClientModule inside AppModule

    // read the base API Url from the environment file and then append the needed URL per method
    return this.http.get<Employee[]>(`${environment.apiUrl}employee/listemployees`);

  }
  //https://localhost:44388/api/Employee/ListEmployees

}

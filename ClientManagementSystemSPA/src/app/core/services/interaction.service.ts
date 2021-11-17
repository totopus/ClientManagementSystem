import { Injectable } from '@angular/core';
import { Interaction } from 'src/app/shared/models/interaction';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  constructor(private http:HttpClient) { }

  getInteractionDetailById(id: number): Observable<Interaction> {
    // appsetting.json 
    // https://localhost:5001/api/movies/3
    return this.http.get<Interaction>(`${environment.apiUrl}interaction/${id}`);
  }

  
  getAllInteractions(): Observable<Interaction[]> {
    // call our API, using HttpClient (XMLHttpRequest) to make GET request
    // HttpClient class comes from HttpClientModule (Angular Team created for us to use)
    // import HttpClientModule inside AppModule

    // read the base API Url from the environment file and then append the needed URL per method
    return this.http.get<Interaction[]>(`${environment.apiUrl}interaction/listinteractions`);

  }
  //https://localhost:44388/api/Interaction/ListInteractions

}

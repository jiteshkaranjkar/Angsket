import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Configuration, OpenAIApi } from 'openai';
import { catchError, map, Observable, takeUntil } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OpenAiService {
  private openai: OpenAIApi;
  constructor(private httpClient: HttpClient) {
    this.openai = new OpenAIApi(this.configuration);
  }

  readonly configuration = new Configuration({
    apiKey: environment.openAiKey
  });

  public getChatGptResponse(query: string): Observable<string> {
    return new Observable(observer => {
      this.openai.createCompletion({
        model: "text-davinci-003",
        prompt: query,
        max_tokens: 100
      }).then(response => {
        return response.data.choices[0].text
      })
        .then((data: any) => {
        observer.next(data);
        observer.complete();
        })
        .catch((err: any) => {
        console.log(err);
      })
    });
  }

  public getCountyByName(name: string): Observable<any> {
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append('Accept', 'application/json');
    headers = headers.append("X-RapidAPI-Key", "ec86dc05dfmsh156de05d9cc5962p14d878jsn22ea797918ac");
    headers = headers.append("X-RapidAPI-Host", "apidojo-yahoo-finance-v1.p.rapidapi.com");
    return this.httpClient.get(`https://apidojo-yahoo-finance-v1.p.rapidapi.com/stock/v2/get-summary` ,
      { headers: headers }
    ).pipe(
      map(response =>
      {
        return response
        console.log(response);
      }),
      catchError(error => {
        return error
      })
    )
  }
}

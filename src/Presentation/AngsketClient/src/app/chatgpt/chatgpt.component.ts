import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common'
import { fromEvent, interval, map, Observable, of, retry, Subject, takeUntil } from 'rxjs';
import { OpenAiService } from '../services/open-ai.service';

@Component({
  selector: 'chatgpt',
  templateUrl: './chatgpt.component.html',
  styleUrls: ['./chatgpt.component.scss']
})
export class ChatgptComponent implements OnInit {
  protected ngUnsubscribe = new Subject();
  public agents: Observable<string> | undefined;
  public agentName: string | undefined;
  constructor(private openaiService: OpenAiService) { }

  public chatGptResponse: any = "Chatgpt";

  student$: Observable<string | undefined> = of("John", "Donna", "Laura");
  students: Observable<string[] | undefined> = of(["John", "Donna", "Laura"]);

  studentObj: Observable<object> = of({
    id: 11,
    name: "Pirana",
    age: 10,
    school: "Public school"
  });

  ngOnInit(): void {

    this.students.subscribe((data) => {
      console.log(data);
    });
    this.studentObj.subscribe((data) => {
      console.log(data);
    });

    //this.agents = new Observable(
    //  function (observer) {
    //    try {
    //      observer.next("John");
    //      setInterval(() => {
    //        observer.next("Fona");
    //      }, 3000)
    //      setInterval(() => {
    //        observer.next("Laura");
    //      }, 6000)

    //    } catch (e) {
    //      observer.error(e)
    //    }
    //  }
    //)

    this.student$.subscribe(data => {
      const seqInterval$ = interval(1000);

      seqInterval$.subscribe((seq) =>
      {
        if (seq < 5) {
        console.log(data);
        }
      });
    })
  }

  @ViewChild('sendQuery')
  sendQuery: ElementRef | undefined;

  public getObservableChatGptResponse(query: string) {
    const buttonObservable$ = fromEvent(this.sendQuery?.nativeElement, 'click');

    buttonObservable$.subscribe(data => {
      console.log(data)
    })
  }

  public getChatGptResponse(query: string) {
    this.chatGptResponse = "Hello World Updated"
    this.openaiService.getChatGptResponse(query)
      .subscribe(response => {
        console.log(response)
        this.chatGptResponse = response;
      })
  }

}

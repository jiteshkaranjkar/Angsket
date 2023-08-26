import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { debounce, debounceTime, take } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchForm!: FormGroup;
  @ViewChild('searchInput')
  searchInput!: ElementRef;

  constructor() { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      name: new FormControl('start Search')
    });

    this.searchForm.get('name')?.valueChanges
      .pipe(
        take(5),
        debounceTime(100)
      )
      .subscribe((data) => {
        console.log(data)
      })
  }

  public searchUpKey() {

  }
}

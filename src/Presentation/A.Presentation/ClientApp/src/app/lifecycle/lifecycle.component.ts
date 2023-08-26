import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-lifecycle',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lifecycle.component.html',
  styleUrls: ['./lifecycle.component.css']
})
export class LifeCycleComponent implements OnInit, OnChanges, OnDestroy, DoCheck, AfterContentInit, AfterViewInit, AfterContentChecked, AfterViewChecked {


  ngOnInit(): void {
    console.log('ng On Init called.');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('ng On Init called.');
  }

  ngDoCheck(): void {
    console.log('ng On Init called.');
  }

  ngAfterContentInit(): void {
    console.log('ng On After Content Init called.');
  }

  ngAfterViewInit(): void {
    console.log('ng On After View Init called.');
  }


  ngAfterContentChecked(): void {
    console.log('ng On After Content Checked called.');
  }

  ngAfterViewChecked(): void {
    console.log('ng On After View Checked called.');
  }

  ngOnDestroy(): void {
    console.log('ng On Component Destroyed called.');
  }

}

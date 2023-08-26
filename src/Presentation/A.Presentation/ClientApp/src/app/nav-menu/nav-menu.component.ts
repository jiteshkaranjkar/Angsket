import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
import { NgIf, NgFor } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

/** @title Responsive sidenav */
@Component({
  selector: 'app-nav-menu',
  templateUrl: '/nav-menu.component.html',
  styleUrls: ['/nav-menu.component.css']
})
export class NavMenuComponent implements OnDestroy {
  mobileQuery: MediaQueryList;
  isExpanded: boolean = false;
  badgevisible: boolean = false;
  isLoggedIn: boolean = false;

  fillerNav = Array.from({ length: 3 }, (_, i) => `Nav Item ${i + 1}`);

  fillerContent = Array.from(
    { length: 3 },
    () =>
      `Lorem ipsum dolor sit amet.`,
  );

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  shouldRun = /(^|.)(stackblitz|webcontainer).(io|com)$/.test(window.location.host);
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

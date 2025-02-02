import { Component, inject } from '@angular/core';
import { MeatWoodView } from '../../models/meatwood.model';
import { MeatwoodviewService } from '../../services/meatwoodview.service';
import { MeatSmokingGuide } from '../../models/meatsmokingguide.model';

@Component({
  selector: 'app-automatic',
  templateUrl: './automatic.component.html',
  styleUrls: ['./automatic.component.css']
})
export class AutomaticComponent {
  meatwoodService = inject(MeatwoodviewService);
  meatwoods?: MeatWoodView[];
  meats?: MeatSmokingGuide[];
  meat?: MeatSmokingGuide = {
    id: 0,
    meattype: null,
    meatcut: null,
    smokingtemp: null,
    approxtime: null,
    approxtime2: null,
    internaltemp: null,
  }

  getSelections(): void {
    this.meatwoodService.get()
      .subscribe({
        next: (m) => {
          this.meats=m;
          console.log(m);
        },
        error: (e) => {
          console.error(e);
        }
      });
  }
}

import {Component} from '@angular/core';

@Component({
  selector: 'app-manual',
  templateUrl: './manual.component.html',
  styleUrls: ['./manual.component.css']
})
export class ManualComponent {
  inputdate: any = null;
  inputtime: any = null;

  log():void {
    
    console.log(this.inputdate, '\n', this.inputtime);
  }

}

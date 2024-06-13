import
{
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { IDuaRequestTypeDto, DuaTypeClient } from '../../../../../NSwag/nswag-api';

@Component({
  selector: 'app-dua-types',
  templateUrl: './dua-types.component.html',
  styles: `
    tr:nth-child(even) {
        background: #F2F2F2;
    }
    tr:nth-child(odd) {
        background: #FFF;
    }
    th, td {
        padding-left: 1rem;
        padding-right: 1rem;
    }
    table {
        margin: 0 auto;
    }
    h1 {
      background-color: rgba(0, 0, 0, .3);
    }
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DuaTypesComponent implements OnInit
{
  allTypes?: IDuaRequestTypeDto[];

  constructor(
    private duaTypeClient: DuaTypeClient,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit()
  {
    this.getForecasts();
  }

  getForecasts()
  {
    this.duaTypeClient.returnAll().subscribe({
      next: (all) =>
      {
        console.log(all);

        this.allTypes = all;

        this.cd.markForCheck();
      },
    });
  }
}

import { InteractionService } from '../../core/services/interaction.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Interaction } from 'src/app/shared/models/interaction';

@Component({
  selector: 'app-interaction-list',
  templateUrl: './interaction-list.component.html',
  styleUrls: ['./interaction-list.component.css']
})
export class InteractionListComponent implements OnInit {

  interactions:Interaction[]=[];
  interactionId: number = -1;

  constructor(private interactionService:InteractionService,
    private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.interactionService.getAllInteractions()
        .subscribe(c => {
          this.interactions = c;
        });
    }
  );
  }

}

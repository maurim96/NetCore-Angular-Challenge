import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionCarrouselComponent } from './competition-carrousel.component';

describe('CompetitionCarrouselComponent', () => {
  let component: CompetitionCarrouselComponent;
  let fixture: ComponentFixture<CompetitionCarrouselComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionCarrouselComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionCarrouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

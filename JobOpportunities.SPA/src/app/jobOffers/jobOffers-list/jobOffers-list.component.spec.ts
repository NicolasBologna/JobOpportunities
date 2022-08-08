import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobOffersListComponent } from './jobOffers-list.component';

describe('jobOffersListComponent', () => {
  let component: JobOffersListComponent;
  let fixture: ComponentFixture<JobOffersListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JobOffersListComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JobOffersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

export interface CreateJobResponseDto {
  id: string;
  candidates: [];
  companyId: string;
  title: string;
  description: string;
  validUntil: Date;
  requiredSkills: [];
}

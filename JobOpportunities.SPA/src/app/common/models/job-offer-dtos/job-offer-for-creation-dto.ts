export interface JobOfferForCreationDto {
  title: string;
  description: string;
  validUntil: Date | string;
  companyId: string;
  requiredSkillsIds: string[];
}

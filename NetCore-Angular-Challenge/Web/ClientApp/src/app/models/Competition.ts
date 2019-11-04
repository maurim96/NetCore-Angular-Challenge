export class Competition {
    id: number;
    name: string;
    areaName: string;
    code: string;
};
export class CompetitionApiResponse {
    competitions: Competition[];
    count: number;
};
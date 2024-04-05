import { solvePart1 } from "./solvers.js";

describe('part1', () => {
	test('input1', () => {
		const entries = [
			"467..114..",
			"...*......",
			"..35..633.",
			"......#...",
			"617*......",
			".....+.58.",
			"..592.....",
			"......755.",
			"...$.*....",
			".664.598..",
		];
		const actual = solvePart1(entries);
		
		expect(actual).toBe(4361);
	})
	test('one digit before symbol', () => {
		const entries = [
			"1*",
		];
		const actual = solvePart1(entries);
		
		expect(actual).toBe(1);
	});
	
	test('one digit after symbol', () => {
		const entries = [
			"*1",
		];
		const actual = solvePart1(entries);
		
		expect(actual).toBe(1);
	});
});
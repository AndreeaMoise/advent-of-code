import { compareHands, determineType } from "./solvers";

describe('determineType', () => {
	test('hand 1', () => {
		const actual = determineType("32T3K");
		
		expect(actual).toBe(2);
	});
	
	test('hand 2', () => {
		const actual = determineType("T55J5");
		
		expect(actual).toBe(4);
	});
	
	test('hand 3', () => {
		const actual = determineType("KK677");
		
		expect(actual).toBe(3);
	});
	
	test('hand 4', () => {
		const actual = determineType("KTJJT");
		
		expect(actual).toBe(3);
	});
	
	test('hand 5', () => {
		const actual = determineType("QQQJA");
		
		expect(actual).toBe(4);
	});
});

test('compareHands', () => {
	const actual = compareHands('KK677', 'KTJJT');
	
	expect(actual > 0).toBe(true);
});
export async function copyToClipboard(text) {
    await navigator.clipboard.writeText(text);
}

export function confirmRemove(name) {
    return confirm(`Remove ${name} from observed students?`);
}
